#pragma once

#ifndef _MAIN_H
#define _MAIN_H

#include <Windows.h>

DWORD WINAPI DllMain(HMODULE, DWORD_PTR, LPVOID);
extern "C" __declspec(dllexport) DWORD Initialise(LPCWSTR);

#endif