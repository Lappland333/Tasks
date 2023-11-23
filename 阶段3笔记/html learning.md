# HTML

> HTML(Hyper Text Markup Language)超文本标记语言是设计用于在Web 浏览器中显示的文档的标准标记语言  
>
> 它定义了网页内容的含义和结构

## HTML标签

> HTML经历了很多次版本迭代，这里以HTML 5为准
>
> 这里列出了我认为比较常用的标签

**基础**	 

|标签|用途|
|-----------|----------------|
|<!DOCTYPE>|定义文档类型。 |
|&lt;html&gt;| 定义一个 HTML 文档 |
|&lt;title&gt;| 为文档定义一个标题|
|&lt;body&gt;| 定义文档的主体|
|&lt;h1&gt;to &lt;h6&gt;| 定义 HTML 标题|
|&lt;p&gt;| 定义一个段落|
|&lt;br&gt;| 定义简单的折行|
|&lt;hr&gt;|定义水平线|
|&lt;!--...--&gt;| 定义一个注释|

**格式**	 
|标签|用途|
|-----------|----------------|
|&lt;abbr>|	定义一个缩写|
|&lt;b>	|定义粗体文本|
|&lt;cite>|定义计算机代码文本|
|&lt;del>|定义被删除文本|
|&lt;dfn>|定义定义项目|
|&lt;em>|定义强调文本 |
|&lt;i>|定义斜体文本|
|&lt;s>|定义加删除线的文本|
|&lt;time>New|定义一个日期/时间|
|&lt;u>|定义下划线文本|
|&lt;wbr>New|规定在文本中的何处适合添加换行符|
**图像**	 

|标签|用途|
|-----------|----------------|
|&lt;img>	|定义图像|
|&lt;canvas>New|通过脚本（通常是 JavaScript）来绘制图形|
|&lt;audio>New|定义声音，比如音乐或其他音频流|
|&lt;video>New|定义一个音频或者视频|
**列表**	 
|标签|用途|
|-----------|----------------|
|&lt;ul>|定义一个无序列表|
|&lt;ol>|定义一个有序列表|
|&lt;li>|定义一个列表项|
|&lt;dl>|定义一个定义列表|
|&lt;dt>|定义一个定义定义列表中的项目|
|&lt;dd>|定义定义列表中项目的描述|
|&lt;menu>|定义菜单列表|
|&lt;command>New|定义用户可能调用的命令（比如单选按钮、复选框或按钮）|
**表格**
|标签|用途|
|-----------|----------------|
|&lt;table>|定义一个表格|
|&lt;caption>|	定义表格标题|
|&lt;th>|定义表格中的表头单元格|
|&lt;tr>|定义表格中的行|
|&lt;td>|定义表格中的单元|
**样式/节**	 
|标签|用途|
|-----------|----------------|
|&lt;style>|定义文档的样式信息|
|&lt;div>|定义文档中的节|
|&lt;header>New|定义一个文档头部部分|
|&lt;footer>New|定义一个文档底部|
|&lt;section>New|定义了文档的某个区域|
|&lt;article>New|定义一个文章内容|
|&lt;aside>New|定义其所处内容之外的内容|
|&lt;details>New|定义了用户可见的或者隐藏的需求的补充细节|
|&lt;dialog>New|定义一个对话框或者窗口|
|&lt;summary>New|定义一个可见的标题，当用户点击标题时会显示出详细信息|



> 由于Markdown语法可以识别一些html标签，所以当想要让html标签显示出来时通常会被解析
>
> 所以这里用到了一点小技巧：
>
> 在转义字符中`&lt`代表`<`,`&gt`代表`>`
>
> 且html的标签在外由`< >`围住，才能被识别为html标记语言
>
> 所以我们可以利用转义字符，替换掉原来的`<`或`>`,破坏标签的结构，以此达到正常显示的效果



## 块级元素与内联元素

> 先明确一下，html中的元素指html文件中的基本组成单元
>
> 它可以是任何符合规定(DTD)的格式,如标题、段落、链接、列表、标签等

> html中的标签元素大体被分为块级元素和内联元素

**块级元素特点：**

1、每个块级元素都从新的一行开始，并且其后的元素也另起一行,也就是说一个块级元素独占一行

2、元素的高度、宽度、行高以及顶和底边距都可设置

3、元素宽度在不设置的情况下，和父元素的宽度一致

常用的块级元素有：

&lt;div>、&lt;p>、&lt;h1>...<h6&gt;、&lt;ol>、&lt;ul>、&lt;dl>、&lt;table>、&lt;address>、&lt;blockquote> 、&lt;form&gt;

> 设置display:block；可以将元素转换块级元素。

**内联元素特点：**

1、和其他元素都在一行上

2、元素的高度、宽度及顶部和底部边距不可设置

3、元素的宽度就是它包含的文字或图片的宽度，不可改变

常用的内联元素有：

&lt;a>、&lt;span>、&lt;br>、&lt;i>、&lt;em>、&lt;strong>、&lt;label>、&ltq>

> 设置display:inline;可以将块状元素转换为内联元素

## HTML标签的样式

先展示一个简单的html

```{
<!DOCTYPE html>
<html>
  <head>
    <style>
       .highlight {background-color: yellow;}
       #special {font-weight: bold;}
    </style>
     <title>Page Title</title>
  </head>
  <body>

     <h1 class="highlight">这是一个标题</h1>
     <p id="special">这是一个段落。</p>
     <p class="highlight">这是一个高亮的段落。</p>

  </body>
</html>
```

* HTML标签的样式通过CSS控制。在HTML文档中，可以使用`<style>`元素来规定浏览器如何渲染HTML文档。`<style>`元素默认情况下包含的是CSS格式的样式信息。此外，每个HTML文档可以包含多个`<style>`标签。
* 在上面的例子中，我利用`<style>`将背景颜色设置为黄色，还使用了ID选择器来选择具有"special" ID的段落，并将其字体加粗。

还有一些其他的知识点，借这个例子一并说明：

- `<!DOCTYPE html>`声明定义该文档是 HTML5 文档

- `<html>`元素是 HTML 页面的根元素

- `<head>`元素包含有关 HTML 页面的元信息

- `<title>`元素指定 HTML 页面的标题（显示在浏览器的标题栏或页面的选项卡中）

- `<body>`定义文档的主体，是所有可见内容的容器，例如标题、段落、图像、超链接、表格、列表等

- `<h1>`元素定义了一个大标题

- `<p>`元素定义一个段落

- body元素是p元素的父元素

  p元素是body元素的子元素

  head元素，body元素和p元素都是html元素的后代元素，但只有head元素和body元素是html元素的子元素

  head元素和body元素互为兄弟元素

## 参考网站

[HTML-wiki](https://en.wikipedia.org/wiki/HTML)

[CSDN-HTML中父元素、子元素、后代元素和兄弟元素](https://blog.csdn.net/qq_46241430/article/details/119296829)

```

```