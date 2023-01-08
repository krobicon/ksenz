#!/bin/bash
serviceName="project-ksenz"

# ====================
# 
# ====================
dotnet publish "src/ksenz/ksenz.csproj" --output "bin" --runtime linux-x64 --self-contained \
  "-p:Configuration=Release" \
  "-p:DebugType=None" \
  "-p:GenerateRuntimeConfigurationFiles=true" \
  "-p:PublishSingleFile=true"

# ====================
# 
# ====================
if [ $serviceName != "ksenz" ]; then
  mv "bin/ksenz" "bin/${serviceName}"
fi

# ====================
# 
# ====================
"bin/${serviceName}"
