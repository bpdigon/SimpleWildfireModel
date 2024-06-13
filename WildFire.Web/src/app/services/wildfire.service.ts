import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { SimEnvironment } from "../models/SimEnvironment";
import { Observable } from "rxjs";

@Injectable()
export class WildFireService{
    //This is the API's local address so that the UI can connect to it.
    private readonly url: string = 'localhost:7140/';

    Environment: SimEnvironment | undefined;

    constructor(private readonly http: HttpClient){}

    //Input is the simEnvironment, leave the turn attribute null
    public putTurn(request: SimEnvironment): Observable<SimEnvironment>{
        return this.http.put<SimEnvironment>(`${this.url}/Turn`, {params: {sim: request}});
    }

    //Input is the simEnvironment, turn attribute CANNOT be null must be greater than 0
    public putXTurns(request: SimEnvironment): Observable<SimEnvironment>{
        return this.http.put<SimEnvironment>(`${this.url}/XTurns`, {params: {sim: request}});
    }

    //Requires a size for the terrain square to be larger than 0 and not null
    public putGenerateTerrain(simNum: number): Observable<SimEnvironment>{
        return this.http.put<SimEnvironment>(`${this.url}/GenerateTerrain`, {params: {simSize: simNum}});
    }

    public setEnvironment(env: SimEnvironment){
        this.Environment = env;
    }

    public getEnvironment(): any{
        if(this.Environment != undefined){
            return this.Environment;
        }
    }

}