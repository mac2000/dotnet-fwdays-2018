from locust import HttpLocust, TaskSet

def ping(l):
    l.client.get("/api/demo/ping")

def load(l):
    l.client.get("/api/demo/load")

class UserBehavior(TaskSet):
    tasks = {ping: 20, load: 1}

class WebsiteUser(HttpLocust):
    task_set = UserBehavior
    min_wait = 5000
    max_wait = 9000
