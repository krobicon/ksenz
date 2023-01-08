#!/bin/bash
serviceName="project-popos"

# ====================
# 
# ====================
dotnet publish "src/popos/popos.csproj" --output "bin" --runtime linux-x64 --self-contained \
  "-p:Configuration=Release" \
  "-p:DebugType=None" \
  "-p:GenerateRuntimeConfigurationFiles=true" \
  "-p:PublishSingleFile=true"

# ====================
# 
# ====================
if [ $serviceName != "popos" ]; then
  mv "bin/popos" "bin/${serviceName}"
fi

# ====================
# 
# ====================
"bin/${serviceName}"
