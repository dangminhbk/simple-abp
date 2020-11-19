docker rm -f simple-blog-web

docker rmi -f aspnet/simple-blog-web

docker build -t aspnet/simple-blog-web .

docker run --name simple-blog-web -d -p 8082:80 aspnet/simple-blog-web