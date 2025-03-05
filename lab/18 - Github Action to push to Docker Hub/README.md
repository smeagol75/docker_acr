# 18

## Github Action

```yml
name: '18 - Github Action to push to Docker Hub'

on:
  push:
    branches: [ "main" ]
  pull_request:
    branches: [ "main" ]

jobs:

  build-and-push:

    runs-on: ubuntu-latest

    steps:

    - uses: actions/checkout@v4
    - name: '🐋 build Docker image'
      working-directory: ./path/to/my/code
      run: docker build -t my-docker-hub-username/my-image .

    - name: '🐋 log in to Docker Hub'
      run: echo ${{ secrets.DOCKER_HUB_TOKEN }} | docker login -u ${{ vars.DOCKER_HUB_USERNAME }} --password-stdin      
      
    - name: '🐋 push image to Docker Hub'
      run: docker push my-docker-hub-username/my-image
```