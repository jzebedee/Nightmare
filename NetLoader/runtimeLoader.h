#pragma once

#include <metahost.h>
#include <CorError.h>
#include "debug.h"

#pragma comment(lib,"MSCorEE.lib") 

class runtimeLoader
{
private:
	ICLRMetaHost* pMetaHost;
	ICLRRuntimeInfo* pRuntimeInfo;
	ICLRRuntimeHost* pRuntimeHost;

	HMODULE lpParam;

public:
	runtimeLoader();
	DWORD WINAPI LoadCore(LPCWSTR);
	~runtimeLoader();
};

