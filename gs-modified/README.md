# gs-modified

## 实现原理
### GS.Unitive.Framework
通过对 `GS.Unitive.Framework.Core` 的 `LicenseValidation` 类的 `Verify` 方法进行修改，使其返回值恒为真，以绕过通软的插件认证检测。

### Cirno.GS.Injection.Test
Dll 包含了一个继承 `IAddonActivator` 的类，作为通软加载插件的入口。
