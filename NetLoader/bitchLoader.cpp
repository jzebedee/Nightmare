#include "bitchLoader.h"

bitchLoader::bitchLoader()
{
}

DWORD WINAPI bitchLoader::LoadCore(PVOID invoid) {
	PINIT_STRUCT instruct = reinterpret_cast<PINIT_STRUCT>(invoid);

	HRESULT hr;

	// The .NET assembly to load.
	bstr_t bstrAssemblyName(instruct->AssemblyPath);
	_AssemblyPtr spAssembly = NULL;

	// The .NET class to instantiate.
	bstr_t bstrClassName(instruct->ClassName);
	_TypePtr spType = NULL;
	variant_t vtObject;
	variant_t vtEmpty;

	// The static method in the .NET class to invoke.
	bstr_t bstrStaticMethodName(instruct->MethodName);
	variant_t vtStringArg(instruct->Argument);
	variant_t vtLengthRet;

	hr = CLRCreateInstance(CLSID_CLRMetaHost, IID_PPV_ARGS(&pMetaHost));
	if (FAILED(hr))
		return -1;

	// Get the ICLRRuntimeInfo corresponding to a particular CLR version. It 
	// supersedes CorBindToRuntimeEx with STARTUP_LOADER_SAFEMODE.
	hr = pMetaHost->GetRuntime(L"v2.0.50727", IID_PPV_ARGS(&pRuntimeInfo));
	if (FAILED(hr))
		return -2;

	// Check if the specified runtime can be loaded into the process. This 
	// method will take into account other runtimes that may already be 
	// loaded into the process and set pbLoadable to TRUE if this runtime can 
	// be loaded in an in-process side-by-side fashion. 
	BOOL fLoadable;
	hr = pRuntimeInfo->IsLoadable(&fLoadable);
	if (FAILED(hr))
		return -3;

	if (!fLoadable)
		return -4;

	// Load the CLR into the current process and return a runtime interface 
	// pointer. ICorRuntimeHost and ICLRRuntimeHost are the two CLR hosting  
	// interfaces supported by CLR 4.0. Here we demo the ICorRuntimeHost 
	// interface that was provided in .NET v1.x, and is compatible with all 
	// .NET Frameworks. 
	hr = pRuntimeInfo->GetInterface(CLSID_CorRuntimeHost, IID_PPV_ARGS(&pCorRuntimeHost));
	if (FAILED(hr))
		return -5;

	// Start the CLR.
	hr = pCorRuntimeHost->Start();
	if (FAILED(hr))
		return -6;

	// Get a pointer to the default AppDomain in the CLR.
	hr = pCorRuntimeHost->GetDefaultDomain(&spAppDomainThunk);
	if (FAILED(hr))
		return -7;

	hr = spAppDomainThunk->QueryInterface(IID_PPV_ARGS(&spDefaultAppDomain));
	if (FAILED(hr))
		return -8;

	// Load the .NET assembly.
	hr = spDefaultAppDomain->Load_2(bstrAssemblyName, &spAssembly);
	if (FAILED(hr)) {
		wchar_t bRes[64];
		wsprintf(bRes, L"failed w/hr 0x%08lx\n", hr);
		::MessageBox(NULL, bRes, L"Failure -9", MB_OK);
		return -9;
	}

	hr = spAssembly->GetType_2(bstrClassName, &spType);
	if (FAILED(hr))
		return -10;

	// Create a safe array to contain the arguments of the method. The safe 
	// array must be created with vt = VT_VARIANT because .NET reflection 
	// expects an array of Object - VT_VARIANT. There is only one argument, 
	// so cElements = 1.
	psaStaticMethodArgs = SafeArrayCreateVector(VT_VARIANT, 0, 1);
	LONG index = 0;
	hr = SafeArrayPutElement(psaStaticMethodArgs, &index, &vtStringArg);
	if (FAILED(hr))
		return -11;

	// Invoke the method from the Type interface.
	hr = spType->InvokeMember_3(bstrStaticMethodName, static_cast<BindingFlags>(
		BindingFlags_InvokeMethod | BindingFlags_Static | BindingFlags_Public),
		NULL, vtEmpty, psaStaticMethodArgs, &vtLengthRet);
	if (FAILED(hr))
		return -12;

#ifdef DEBUG
	// Print the call result of the static method.
	wchar_t bRes[64];
	wsprintf(bRes, L"%d", vtLengthRet.lVal);

	::MessageBox(NULL, bRes, L"vtLengthRet.lVal", MB_OK);
#endif

	return 0;
}

bitchLoader::~bitchLoader()
{
	if (pMetaHost)
	{
		pMetaHost->Release();
		pMetaHost = NULL;
	}

	if (pRuntimeInfo)
	{
		pRuntimeInfo->Release();
		pRuntimeInfo = NULL;
	}

	if (pCorRuntimeHost)
	{
		// Please note that after a call to Stop, the CLR cannot be 
		// reinitialized into the same process. This step is usually not 
		// necessary. You can leave the .NET runtime loaded in your process.
		//wprintf(L"Stop the .NET runtime\n");
		//pCorRuntimeHost->Stop();

		pCorRuntimeHost->Release();
		pCorRuntimeHost = NULL;
	}

	if (psaStaticMethodArgs)
	{
		SafeArrayDestroy(psaStaticMethodArgs);
		psaStaticMethodArgs = NULL;
	}
}
