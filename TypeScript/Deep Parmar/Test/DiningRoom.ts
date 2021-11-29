import {Table} from './Table'


interface IDiningRoom
{
    RoomId:number;
    Tables:Table[];
    Isavailable:boolean;
}

export class DiningRoom implements IDiningRoom
{
    RoomId:number;
    Tables:Table[];
    Isavailable:boolean;

    constructor(RoomId:number,Tables:Table[],Isavailable:boolean) {
        this.RoomId=RoomId;
        this.Tables=Tables;
        this.Isavailable=Isavailable
    }
}