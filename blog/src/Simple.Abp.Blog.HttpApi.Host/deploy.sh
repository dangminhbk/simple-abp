docker rm -f simple-blog-api

docker rmi -f aspnet/simple-blog-api

docker build -t aspnet/simple-blog-api .

docker run --name simple-blog-api -d -p 8080:80 aspnet/simple-blog-api