# I build an app

So here we go, I have build an awesome dotnet core app.

To run it, just clone repository and `dotnet run` it.

You gonna see conference logo, host name at top left and current time on a server at top right corners.

At bottom there is few demo buttons to play with

Ping do nothing - just to check that app is still alive

Load CPU - will load one core for ten seconds

Both exit buttons will exit app with acccording exit code

# How should I deploy it

Hard way - buy a server, setup Windows, configure IIS

Fun way - dockerize it

You can find sample docker file in this repo

To build it run `docker build -t mac2000/dotnet-fwdays-2018 .`

To run it `docker run -it --rm -p 5000:80 mac2000/dotnet-fwdays-2018`

**Notice:** When you run app with `dotnet run` and load cpu - you will see dotnet executable eating cpu in your task manager, when running inside container - you gonna see your docker eating cpu, also you will see hostname from docker image rather than your maching

**Experiment:**

Run your app like this: `docker run -d --name=dotnet-fwdays-2018 --restart=always -p 5000:80 mac2000/dotnet-fwdays-2018`

Then check it is here with `docker ps`

Try to exit it either with zero or non zero exit code

Check again your `doccker ps` you will see that your app is here again

PS: to remove it `docker rm -f mac2000/dotnet-fwdays-2018`

# Kubernetes

We gonna use Kubernetes to make our live easy and fun again

For this we need only 3 things:

## Deployment

Describe our `deployment.yml` which you can think of as `docker-compose.yml`

All it does is just describes which containers and with which configuration options Kubernetes should run

Now run it: `kubectl apply -f deployment.yml`

Check it is running with `kubectl get deployments`

Notice for this to run you gonna need to publish your image to docker hub

## Service

Your deployment is up and running somewhere deep inside your kubernetes cluster. Service is used to expose it to world, think about it as ELB

In general in `service.yml` you will describte wich containers and ports should be exposes nothing more

Now apply it: `kubectl apply -f service.yml`

Check it is running `kubectl get services`

**Notice:** no matter what we are doing all we need is to `apply` another yaml file to kubernetes whether it is deployment, service or anything else. Also there is `get` command to look inside, and `delete` to cleanup

**Experiment:**

Kubernetes is a state machine to understand how it works try to change replicas inside your `deployment.yml` to something else and run `kubectl apply -f deployment.yml`

## Horizontal Pod Autoscaler

Kubernetes not only looks for your apps to be up and running but also can autoscale them. Take a look at `autoscale.yml` for example

Apply it with `kubectl apply -f autoscale.yml`

Check it with `kubectl get horizontalpodautoscaler`

Unfortunatelly at moment I was unable to make it work under local kubernetes so moving everything to cloud


# Notes

For local k8s I were forced to clone

```sh
git clone https://github.com/kubernetes-incubator/metrics-server
kubectl create -f metrics-server/deploy/1.8+/
git clone https://github.com/kubernetes/heapster
kubectl create -f heapster/deploy/kube-config/rbac/
kubectl create -f ../heapster/deploy/kube-config/standalone/
kubectl create -f ../heapster/deploy/kube-config/standalone-with-apiserver/
kubectl create -f ../heapster/deploy/kube-config/influxdb/
git clone https://github.com/kubernetes/kube-state-metrics
kubectl apply -f kube-state-metrics/kubernetes/
```
