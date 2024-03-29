
### Creating an image (should be executed on same dir as dockerfile)
 * docker build -t samplewebappe:1.0.1 --build-arg="$BuilderName=Anurag" .
 * docker build -f "second.dockerfile" -t samplewebappe:1.2.0 --build-arg="$BuilderName=Anurag" .
 
 ### running the image (creating container)
* docker run -p 9000:80 samplewebappe:1.2.0

### pushing the changes to dockerhub repository
* docker tag samplewebapp:1.2.0 ruhelaanurag/mysampleapp
* docker push ruhelaanurag/mysampleapp