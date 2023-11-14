# Github进阶

## 内容目录

* 查阅别人的代码
* 在线编辑
* 和Github Desktop配套使用（Git与Github的区别）
* 遇到的问题（SSH Key的公钥格式）

## 内容

* 查阅别人的代码
在Github中我们可以非常快捷地查看许多项目的源代码，如编程语言Python和扩散模型Diffusion  Model，便于我们查阅和学习。
* 在线编辑
对于自己上传的文件，可以直接点击preview旁边的code进行修改并上传。
或者使用 github.dev 编辑器，可以从 GitHub 中导航文件和源代码存储库，并创建和提交代码更改。
* 和Github Desktop配套使用（Git与Github的区别）
Git可以认为是一个软件，能够帮你更好的写程序，是一个版本管理的工具，Github则是一个网站，这个网站可以帮助程序员之间互相交流和学习。
使用Github Desktop可以快捷地管理仓库和本地文件，从而绕开Git Bash中繁琐的命令，将本地文件推送至Github上的仓库。
* 遇到的问题（SSH Key的公钥格式）
如果要通过Git Bash中键入命令将本地文件推送至仓库，那么其中一种方法是通过在Github上添加SSH Key来在两者之间建立联系。而我在Github添加新的SSH Key的过程中总是会显示“您必须提供公钥格式的密钥（You must supply a key in OpenSSH public key format)”，但是我确实加的是.ssh文件里的id_rsa.pub（公钥）。这导致无法添加密钥，从而无法顺利将本地文件推送至仓库。最后由于时间原因不得不放弃在Git Bash中用命令，尝试用Github Desktop才顺利将本地文件上传。

## 感想

Github作为一个代码托管网站和编程社交平台有很多强大的功能，并且其中有很多开源项目供大家学习。我的直观感受是通过Git直接下达命令比用可视化界面操作要简洁得多，但是对对于语法的熟悉程度要求较高。以后会尽力去学习的。



### 参考资料
[Github-About remote repositories](https://docs.github.com/en/get-started/getting-started-with-git/about-remote-repositories)

[wiki-Github](https://en.wikipedia.org/wiki/GitHub)

