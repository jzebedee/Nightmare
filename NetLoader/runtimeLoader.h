#pragma once

#include <metahost.h>

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

