# Home Assistant Windows service
This is a service that allows me to have basic control of my windows computers without having to reveal any secrets (such as windows login creds)

I use this with the Wake on LAN feature of home assistant as follows:
```yaml
switch:
  - platform: wake_on_lan
    name: Work Laptop
    mac: XX-XX-XX-XX-XX-XX
    host: 192.168.1.ZZZ
    turn_off:
      service: rest_command.hibernate_work_laptop
```
and
```yaml
rest_command:
  hibernate_work_laptop:
    url: http://192.168.1.ZZZ:5001/remote/hibernate
    method: post
    headers:
      x-functions-key: "a-magic-value-that-can-be-a-secret-here"
    content_type: "application/json"
```

and in the `Remote.Service.exe.config` on the machine you want to control you need to ensure these match up.
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.8" />
    </startup>
  <appSettings>
    <!-- These values need to match the rest command values for port number and the x-functions-key-->
    <add key="headerKey" value="a-magic-value-that-can-be-a-secret-here"/>
    <add key="url" value="http://*:5001/"/>
  </appSettings>
</configuration>
```

Commands that can be called include:
- `/remote/hibernate` attempts to put the machine in to hibernation.
- `/remote/screen` attempts to turn off the screen(s).
- `/remote/sleep` attempts to put the computer to sleep.
