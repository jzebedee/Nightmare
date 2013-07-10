#pragma once

#include <metahost.h>
#include <windows.h>
#include "main.h"

#pragma comment(lib,"MSCorEE.lib") 

#import "C:\Windows\Microsoft.NET\Framework64\v2.0.50727\mscorlib.tlb" raw_interfaces_only				\
	high_property_prefixes("_get", "_put", "_putref")		\
	rename("ReportEvent", "InteropServices_ReportEvent")
using namespace mscorlib;

class bitchLoader
{
private:
	ICLRMetaHost *pMetaHost;
	ICLRRuntimeInfo *pRuntimeInfo;

	ICorRuntimeHost *pCorRuntimeHost;
	IUnknownPtr spAppDomainThunk;
	_AppDomainPtr spDefaultAppDomain;

	SAFEARRAY *psaStaticMethodArgs;

public:
	bitchLoader();
	DWORD WINAPI LoadCore(PVOID);
	~bitchLoader();
};

