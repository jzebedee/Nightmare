#pragma once

#ifndef _MAIN_H
#define _MAIN_H

#include <Windows.h>
#include "debug.h"
#include "runtimeLoader.h"

typedef struct _INIT_STRUCT {
	LPCWSTR Path;
} INIT_STRUCT, *PINIT_STRUCT;

DWORD WINAPI DllMain(HMODULE, DWORD_PTR, LPVOID);
extern "C" __declspec(dllexport) DWORD Initialise(PVOID);

#endif