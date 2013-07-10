#pragma once

#ifndef _MAIN_H
#define _MAIN_H

#include <Windows.h>
#include "debug.h"
#include "runtimeLoader.h"
#include "bitchLoader.h"

typedef struct _INIT_STRUCT {
	LPCWSTR AssemblyPath;
	LPCWSTR ClassName;
	LPCWSTR MethodName;
	LPCWSTR Argument;
} INIT_STRUCT, *PINIT_STRUCT;

DWORD WINAPI DllMain(HMODULE, DWORD_PTR, LPVOID);
extern "C" __declspec(dllexport) DWORD InitialiseV4(PVOID);
extern "C" __declspec(dllexport) DWORD InitialiseV2(PVOID);

#endif