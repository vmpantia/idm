import { SecurityGroupDTO } from "../security-group-dto.model";

export class SaveSecurityGroupRequest {
    public functionID:string;
    public requestStatus:string;
    public inputSG:SecurityGroupDTO;
}
