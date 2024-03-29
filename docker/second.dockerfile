from nginx
copy ./samplewebapp/ usr/share/nginx/html

# expose 80
# arg ENV="dev"
# arg BuilderName="Docker"
# entrypoint ["echo", "Hello ${ENV} from docker ${BuilderName}"]

# docker build -t samplewebappe:1.0.1 --build-arg="$BuilderName=Anurag" .
# docker build -f "second.dockerfile" -t samplewebappe:1.2.0 --build-arg="$BuilderName=Anurag" .
# docker run -p 9000:80 samplewebappe:1.2.0