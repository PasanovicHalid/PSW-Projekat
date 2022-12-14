export class Email{
    domainName: string = "";
    localPart: string = "";


    public constructor(obj?: any){
        if(obj){
            this.localPart = obj.localPart;
            this.domainName = obj.domainName;
        }
    }
}