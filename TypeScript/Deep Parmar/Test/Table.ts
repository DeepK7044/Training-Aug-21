interface ITable
{
    TableId:number;
    TableCapacity:number;
    Isavailable:boolean;     
}

export class Table implements ITable
{
    TableId:number;
    TableCapacity:number;
    Isavailable:boolean; 

    constructor(TableId:number,TableCapacity:number,Isavailable:boolean) {  
            this.TableId=TableId;
            this.TableCapacity=TableCapacity;
            this.Isavailable=Isavailable;        
    }
}