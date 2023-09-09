
abstract class BaseModel {
    id:string
}

export interface IComment extends BaseModel{
    textComment:string

}
export interface IUser extends BaseModel{
    role:string,
    userName:string,
    password:string,
    email:string,
    phoneNumber:string,
    hashPassword:string
}
export interface IMedia extends File {
    physicalPath:string
    

}
export interface IPhoto extends IMedia{
    heigth:number,
    width:number,
}
export interface ITravel extends BaseModel{
    description:string,
    startDate:Date,
    endDate:Date,
    comments?:IComment[],
    users?:IUser[],
    media?:IMedia[]|File[],
    price:number,

}
export interface ITraveForCreate extends Omit<ITravel,"id">{};