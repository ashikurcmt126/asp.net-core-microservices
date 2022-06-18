1. kubectl apply -f platforms-depl.yaml
2. kubectl get deployments
3. kubectl get pods
4. kubectl delete deployment platforms-depl
5. kubectl rollout restart deployment platforms-depl
6. kubectl create secret generic mssql --from-literal=SA_PASSWORD="pa55w0rd"
