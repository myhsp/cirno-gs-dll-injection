# cirno-gs-dll-injection
给电子班牌狠狠注入神必代码

将班牌根目录的 `GS.Unitive.Framework.dll` 重命名为 `_GS.Unitive.Framework.dll`。复制 `gs-modified/GS.Unitive.Framework_modified.dll` 到班牌程序根目录。将 `gs-modified/GS.Unitive.Framework_modified.dll` 重命名为 `GS.Unitive.Framework.dll`。

## 测试程序
复制 `gs-modified/Cirno.GS.Injection.Test` 到班牌 `Addons` 文件夹。尝试启动。若无法启动则将 `gs-modified/Cirno.GS.Injection.Test/dependencies` 中文件复制到 `gs-modified/Cirno.GS.Injection.Test/` 并用 `gs-modified/GS.Unitive.Framework_modified.dll` 按照之前的方法替换掉 `GS.Unitive.Framework.dll`。

在后台命令面板输入 `0`，出现弹窗。
