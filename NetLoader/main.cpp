#include "main.h"

DWORD WINAPI DllMain(HMODULE, DWORD_PTR, LPVOID) {
	return TRUE;
}

extern "C" __declspec(dllexport) DWORD InitialiseV4(PVOID invoid) {
	PINIT_STRUCT instruct = reinterpret_cast<PINIT_STRUCT>(invoid);

#ifdef DEBUG
	::MessageBox(NULL, instruct->AssemblyPath, L"Hit Initialise", MB_OK);
#endif // DEBUG

	runtimeLoader* rl = new runtimeLoader();
	DWORD res = rl->LoadCore(invoid);

#ifdef DEBUG
	wchar_t bRes[64];
	wsprintf(bRes, L"%d", res);

	::MessageBox(NULL, bRes, L"Leaving Initialise", MB_OK);
#endif // DEBUG

	return res;
}
extern "C" __declspec(dllexport) DWORD InitialiseV2(PVOID invoid) {
	PINIT_STRUCT instruct = reinterpret_cast<PINIT_STRUCT>(invoid);

#ifdef DEBUG
	::MessageBox(NULL, instruct->AssemblyPath, L"Hit Initialise", MB_OK);
#endif // DEBUG

	bitchLoader* bl = new bitchLoader();
	DWORD res = bl->LoadCore(invoid);

#ifdef DEBUG
	wchar_t bRes[64];
	wsprintf(bRes, L"%d", res);

	::MessageBox(NULL, bRes, L"Leaving Initialise", MB_OK);
#endif // DEBUG

	return res;
}