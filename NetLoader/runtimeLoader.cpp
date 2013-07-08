#include "runtimeLoader.h"
#pragma comment(lib,"MSCorEE.lib") 

runtimeLoader::runtimeLoader()
{
}

DWORD WINAPI runtimeLoader::LoadCore(LPCWSTR path)
{
	HRESULT hr;

	hr = CLRCreateInstance(CLSID_CLRMetaHost, IID_ICLRMetaHost, (LPVOID*) &pMetaHost);
	if (FAILED(hr)) return -1;

	////////////////////////////
	// Find latest CLR version
	// from http://www.mmowned.com/forums/world-of-warcraft/bots-programs/memory-editing/303896-injection-outsider-help.html#post1940144
	IEnumUnknown *peunkRuntimes;
	hr = pMetaHost->EnumerateInstalledRuntimes(&peunkRuntimes);
	if (FAILED(hr)) return -2;

	IUnknown *punkRuntime;
	ICLRRuntimeInfo *prtiLatest = NULL;
	WCHAR szLatestRuntimeVersion[MAX_PATH];
	while (peunkRuntimes->Next(1, &punkRuntime, NULL) == S_OK) // returns S_FALSE when no more runtimes remaining
	{
		hr = punkRuntime->QueryInterface(IID_PPV_ARGS(&pRuntimeInfo));
		if (SUCCEEDED(hr))
		{
			if (!prtiLatest)
			{
				hr = pRuntimeInfo->QueryInterface(IID_PPV_ARGS(&prtiLatest));
				if (SUCCEEDED(hr))
				{
					DWORD cch = ARRAYSIZE(szLatestRuntimeVersion);
					hr = prtiLatest->GetVersionString(szLatestRuntimeVersion, &cch);
				}
			}
			else
			{
				WCHAR szCurrentRuntimeVersion[MAX_PATH];
				DWORD cch = ARRAYSIZE(szCurrentRuntimeVersion);
				hr = pRuntimeInfo->GetVersionString(szCurrentRuntimeVersion, &cch);
				::MessageBox(NULL, szCurrentRuntimeVersion, L"Current runtime check", MB_OK);
				if (SUCCEEDED(hr))
				{
					if (wcsncmp(szLatestRuntimeVersion, szCurrentRuntimeVersion, cch) < 0)
					{
						hr = pRuntimeInfo->GetVersionString(szLatestRuntimeVersion, &cch);
						if (SUCCEEDED(hr))
						{
							prtiLatest->Release();
							hr = pRuntimeInfo->QueryInterface(IID_PPV_ARGS(&prtiLatest));
						}
					}
				}
			}
			pRuntimeInfo->Release();
		}
		punkRuntime->Release();
	}
	peunkRuntimes->Release();
	////////////////////////////

	if (!pRuntimeInfo) return -3;

	wchar_t bRes[64];
	DWORD x;
	pRuntimeInfo->GetVersionString(bRes, &x);
	::MessageBox(NULL, bRes, L"pRuntimeInfo version", MB_OK);

	hr = pRuntimeInfo->GetInterface(CLSID_CLRRuntimeHost, IID_ICLRRuntimeHost, (LPVOID*) &pRuntimeHost);// Load the CLR.
	if (FAILED(hr)) return -4;

	hr = pRuntimeHost->Start();
	if (FAILED(hr)) return -5;

	DWORD dwRetCode = 0;
	hr = pRuntimeHost->ExecuteInDefaultAppDomain(path, L"Bloodstream.EntryPoint", L"Main", path, &dwRetCode);

	if (SUCCEEDED(hr)) {
		wchar_t bRes[64];
		wsprintf(bRes, L"%d", dwRetCode);

		::MessageBox(NULL, bRes, L"dwRetCode", MB_OK);
	}
	else if (FAILED(hr)) {
		wchar_t bRes[64];
		wsprintf(bRes, L"%X", hr);

		::MessageBox(NULL, bRes, L"HRESULT == HOST_E_CLRNOTAVAILABLE", MB_OK);

		return -6;
	}

	//hr = pRuntimeHost->UnloadAppDomain(dwRetCode, true);
	//if (FAILED(hr)) return -7;

	//pRuntimeHost->Stop();

	return 0;
}

runtimeLoader::~runtimeLoader()
{
	pMetaHost->Release();
	pRuntimeInfo->Release();
	pRuntimeHost->Release();
}
