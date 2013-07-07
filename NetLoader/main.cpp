#include "main.h"
#include "runtimeLoader.h"

DWORD WINAPI DllMain(HMODULE, DWORD_PTR, LPVOID) {
	return TRUE;
}

extern "C" __declspec(dllexport) DWORD Initialise(LPCWSTR path) {
	runtimeLoader* rl = new runtimeLoader();
	return rl->LoadCore(path);
}