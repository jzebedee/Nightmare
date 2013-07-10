#pragma once

#include <metahost.h>
#include <CorError.h>
#include "main.h"

#pragma comment(lib,"MSCorEE.lib") 

class runtimeLoader
{
private:
	ICLRMetaHost* pMetaHost;
	ICLRRuntimeInfo* pRuntimeInfo;
	ICLRRuntimeHost* pRuntimeHost;

public:
	runtimeLoader();
	DWORD WINAPI LoadCore(PVOID);
	~runtimeLoader();
};

