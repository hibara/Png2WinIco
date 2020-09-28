[English](README.md) / [日本語](README-JP.md)

# Png2WinIco

"png2winIco" is a Windows application that takes a large PNG file and generates an ICO file for Windows that contains resources of each size.

It is a GUI application that can contain larger resources than the existing [png2ico](http://winterdrache.de/freeware/png2ico/) generated ICO files.

"png2ico" does not seem to support the 256px icon size supported in Windows 7. When I try to load a PNG file larger than 256px, I get the following error message.

```shell
Width must be multiple of 8 and <256. Height must be <256.
```

Even now, the last update is on 2002/12/08. I don't think to expect any more updates in the future.

So I developed an application that can generate icons according to the definition of a Windows icon. And on [Microsoft's official documentation](https://docs.microsoft.com/ja-jp/windows/win32/uxguide/vis-icons?redirectedfrom=MSDN#size-requirements), the full set includes 16x16, 32x32, 48x48, and 256x256 (code scales between 32 and 256) that format is required. For Classic Mode, the full set is 16x16, 24x24, 32x32, 48x48, and 64x64.

So this application can output an icon file with the following sizes of resources.

* 256x256
* 64x64
* 48x48
* 32x32
* 24x24
* 16x16

## How to use

Simply, you launch the application and open (or drag and drop) the PNG file.

<img src="img/Png2WinIco_Capture.png" width="512px" />

Then click the "Save" button to save the .ICO file to the specified location.

The recommended size of the PNG file is 256px or larger in both width and height. When resized, if the image is somewhat intricate, the quality of each small size of the .ICO file may be coarse.

## Download

[https://github.com/hibara/Png2WinIco/releases/](https://github.com/hibara/Png2WinIco/releases/)

## History

* v1.0.0.0 ( 2020/09/28 )
  * Initial relese

## Licence

MIT Licence

## Contact Us

[Mituhiro Hibara](mailto:m@hibara.org)
