docker rm -f simple-blog-identityserver

docker rmi -f aspnet/simple-blog-identityserver

docker build -t aspnet/simple-blog-identityserver .

docker run --name simple-blog-identityserver -d -p 8081:80 aspnet/simple-blog-identityserver