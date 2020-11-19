#基于 `mcr.microsoft.com/dotnet/core/aspnet` 来构建我们的镜像
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

#拷贝项目publish文件夹中的所有文件到 docker容器中的publish文件夹中  
COPY . /publish

#设置工作目录为 `/publish` 文件夹，即容器启动默认的文件夹
WORKDIR /publish

#设置Docker容器对外暴露8083端口
EXPOSE 8083

#使用`dotnet Simple.Abp.Blog.Web.Front.dll`来运行应用程序
CMD ["dotnet", "Simple.Abp.Blog.Web.Front.dll", "--server.urls", "http://127.0.0.1:8083"]