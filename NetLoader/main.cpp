#include "main.h"
#include "runtimeLoader.h"

DWORD WINAPI DllMain(HMODULE, DWORD_PTR, LPVOID) {
	return TRUE;
}

extern "C" __declspec(dllexport) DWORD Initialise(PVOID instruct) {
	PINIT_STRUCT pstruct = reinterpret_cast<PINIT_STRUCT>(instruct);

	::MessageBox(NULL, pstruct->Path, L"Hit Initialise", MB_OK);

	runtimeLoader* rl = new runtimeLoader();
	DWORD res = rl->LoadCore(pstruct->Path);

	wchar_t bRes[64];
	wsprintf(bRes, L"%d", res);

	::MessageBox(NULL, bRes, L"Leaving Initialise", MB_OK);

	return res;
}