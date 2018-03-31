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

To build it run `docker build -t dotnet-fwdays-2018 .`

To run it `docker run -it --rm -p 5000:80 dotnet-fwdays-2018`

**Notice:** When you run app with `dotnet run` and load cpu - you will see dotnet executable eating cpu in your task manager, when running inside container - you gonna see your docker eating cpu, also you will see hostname from docker image rather than your maching

**Experiment:**

Run your app like this: `docker run -d --name=dotnet-fwdays-2018 --restart=always -p 5000:80 dotnet-fwdays-2018`

Then check it is here with `docker ps`

Try to exit it either with zero or non zero exit code

Check again your `doccker ps` you will see that your app is here again

PS: to remove it `docker rm -f dotnet-fwdays-2018`
