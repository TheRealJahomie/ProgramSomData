void Main() {
    

}

void arrsum(int n, int arr[], int *sump){
    int i; 
    i = 0;
    int acc; 
    while(i < n){
        acc = acc + arr[i];
        i++; 
    } 
    sump = acc; 
}