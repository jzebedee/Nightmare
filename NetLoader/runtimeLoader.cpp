#include "runtimeLoader.h"

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

	//wchar_t bRes[64];
	//DWORD x;
	//pRuntimeInfo->GetVersionString(bRes, &x);
	//::MessageBox(NULL, bRes, L"pRuntimeInfo version", MB_OK);

	hr = pRuntimeInfo->GetInterface(CLSID_CLRRuntimeHost, IID_ICLRRuntimeHost, (LPVOID*) &pRuntimeHost);// Load the CLR.
	if (FAILED(hr)) return -4;

	hr = pRuntimeHost->Start();
	if (FAILED(hr))
#ifdef DEBUG
	{
		LPCWSTR msg;

		switch (hr) {
		case S_OK:
			msg = L"S_OK";
			break;
		case HOST_E_CLRNOTAVAILABLE:
			msg = L"HOST_E_CLRNOTAVAILABLE";
			break;
		case HOST_E_TIMEOUT:
			msg = L"HOST_E_TIMEOUT";
			break;
		case HOST_E_NOT_OWNER:
			msg = L"HOST_E_NOT_OWNER";
			break;
		case HOST_E_ABANDONED:
			msg = L"HOST_E_ABANDONED";
			break;
		case E_FAIL:
			msg = L"E_FAIL";
			break;
		default:
			msg = L"Unknown";
			break;
		}

		::MessageBox(NULL, msg, L"pRuntimeHost->Start HResult", MB_OK);

#endif
		return -5;
#ifdef DEBUG
	}
#endif

	DWORD dwRetCode = 0;
	hr = pRuntimeHost->ExecuteInDefaultAppDomain(path, L"Bloodstream.EntryPoint", L"Main", path, &dwRetCode);

#ifdef DEBUG
	if (SUCCEEDED(hr)) {
		wchar_t bRes[64];
		wsprintf(bRes, L"%d", dwRetCode);

		::MessageBox(NULL, bRes, L"dwRetCode", MB_OK);
	}
	else
#endif // DEBUG
		if (FAILED(hr)) {
#ifdef DEBUG
			wchar_t bRes[64];
			wsprintf(bRes, L"%X", hr);

			::MessageBox(NULL, bRes, L"HRESULT", MB_OK);

			LPCWSTR msg;

			switch (hr) {
			case S_OK:
				msg = L"S_OK";
				break;
			case HOST_E_CLRNOTAVAILABLE:
				msg = L"HOST_E_CLRNOTAVAILABLE";
				break;
			case HOST_E_TIMEOUT:
				msg = L"HOST_E_TIMEOUT";
				break;
			case HOST_E_NOT_OWNER:
				msg = L"HOST_E_NOT_OWNER";
				break;
			case HOST_E_ABANDONED:
				msg = L"HOST_E_ABANDONED";
				break;
			case E_FAIL:
				msg = L"E_FAIL";
				break;
			default:
				msg = L"Unknown";
				break;
			}

			::MessageBox(NULL, msg, L"HResult Message", MB_OK);


#endif // DEBUG

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
