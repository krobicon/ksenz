# ksenz

git clone https://github.com/krobicon/ksenz
git pull

#OPEN MAIN DIR
cd ~/ksenz

E#NABLE BUILD
chmod +x service-build.sh


R#UN BUILD
./service-build.sh


#OPEN BIN
cd ~/ksenz/bin


#INSTALL IN BIN
./service-install.sh

#UNINSTALL IN BIN
./service-uninstall.sh

# Installation

This guide is written for *Ubuntu*. For other Linux flavors, adapt commands where needed.

## (1) Allow Root Login

We'll ensure that the `root` user can login.

1. Configure your `root` user password:

```
sudo passwd
```

See [this page for more information](https://www.cyberciti.biz/faq/how-can-i-log-in-as-root/) on the root user.

## (2) Enable Process Isolation

We'll ensure that non-root users are unable to see the `project-ksenz` service.

1. Switch to the `root` user:

```
su
```

2. Install dependencies:

```
apt install -y vim
```

3. Open `/etc/fstab` with *vim*:

```
vim /etc/fstab
```

4. Add the following line:

```
proc /proc proc defaults,nosuid,nodev,noexec,relatime,hidepid=1 0 0
```

5. Reboot your system:

```
reboot
```

6. Check that your non-root user cannot see root processes:

```
ps aux
```

See [this page for more information](https://www.kernel.org/doc/Documentation/filesystems/proc.txt) on process isolation.

## (3) Disable Process Tracing

We'll ensure that non-root users cannot use `ptrace` capabilities.

1. Switch to the `root` user:

```
su
```

2. Open `/etc/sysctl.d/10-ptrace.conf` with *vim*:

```
vim /etc/sysctl.d/10-ptrace.conf
```

3. Change the `kernel.yama.ptrace_scope` value to `2`:

```
kernel.yama.ptrace_scope = 2
```

4. Reboot your system:

```
reboot
```

5. Check that the `ptrace_scope` is set to `2`:

```
sysctl kernel.yama.ptrace_scope
```

See [this page for more information](https://www.kernel.org/doc/Documentation/security/Yama.txt) on process tracing.

## (4) Install .NET

We'll ensure that `project-ksenz` can be compiled with *.NET*.

1. Switch to the `root` user:

```
su
```

2. Add the *Microsoft* package repositories:

* See https://docs.microsoft.com/en-us/dotnet/core/install/linux.
* Be sure to carefully follow instructions for your Linux flavor.

3. Install *.NET 6.0*:

```
apt update && apt install -y dotnet-sdk-6.0
```

## (5) Build Service

We'll build `project-ksenz`, so we can register it as a service:

1. Switch to `root` user:

```
su
```

2. Open the `/root` directory: 

```
cd ~
```

3. Install dependencies:

```
apt install -y git
```


