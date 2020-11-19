docker rm -f simple-blog-front

docker rmi -f aspnet/simple-blog-front

docker build -t aspnet/simple-blog-front .

docker run --name simple-blog-front -d -p 8083:80 aspnet/simple-blog-front