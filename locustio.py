from locust import HttpLocust, TaskSet

def ping(l):
    l.client.get("/api/demo/ping")

def load(l):
    l.client.get("/api/demo/load")

class UserBehavior(TaskSet):
    tasks = {ping: 20, load: 10}

class WebsiteUser(HttpLocust):
    task_set = UserBehavior
    min_wait = 5000
    max_wait = 30000

# locust --host=http://35.195.11.75 -f locustio.py
