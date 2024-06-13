import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { SimEnvironment } from "../models/SimEnvironment";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class WildFireService {

    //This is the API's local address so that the UI can connect to it.
    private readonly url: string = 'https://localhost:7140/api/WildFire';

    httpOptions: any;

    Environment: SimEnvironment | undefined;
    
    constructor(private readonly http: HttpClient){

      this.httpOptions = { headers: new HttpHeaders({'Content-Type': 'application/json'})}
    }

    //Input is the simEnvironment, leave the turn attribute null
    public putTurn(request: SimEnvironment): Observable<SimEnvironment>{
        return this.http.put<SimEnvironment>(`${this.url}/Turn`, {params: {sim: request}});
    }

    //Input is the simEnvironment, turn attribute CANNOT be null must be greater than 0
    public putXTurns(request: SimEnvironment): Observable<SimEnvironment>{
        return this.http.put<SimEnvironment>(`${this.url}/XTurns`, {params: {sim: request}});
    }

    //Requires a size for the terrain square to be larger than 0 and not null
    public putGenerateTerrain(simNum: number): Observable<any>{
      console.log("SIOMENUME", simNum);
        return this.http.put(`${this.url}/GenerateTerrain`, simNum, this.httpOptions);
    }

    // public putGenerateTerrain(simNum: number): Observable<any>{
    //       return this.http.get('https://localhost:7140/api/WildFire/test');
    //   }

    public setEnvironment(env: SimEnvironment){
        this.Environment = env;
    }

    public getEnvironment(): any{
        if(this.Environment != undefined){
            return this.Environment;
        }
    }
}
