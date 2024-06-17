import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { SimEnvironment } from "../models/SimEnvironment";
import { Observable } from "rxjs";
import { TerrainType } from '../enum/TerrainTypes.enum';
import { SimulationRequest } from '../DTOs/SimulationRequest';

@Injectable({
    providedIn: 'root'
})
export class WildFireService {

    //This is the API's local address so that the UI can connect to it.
    private readonly url: string = 'https://localhost:7140/api/WildFire';

    httpOptions: any;

    Environment!: SimEnvironment;
    turn: number;

    constructor(private readonly http: HttpClient) {

        this.httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }
        this.turn = 0;

    }

    //Input is the simEnvironment, leave the turn attribute null
    // public putTurn(request: SimulationRequest): Observable<SimulationRequest> {
    //     return this.http.put<SimulationRequest>(`${this.url}/Turn`, { sim: request }, this.httpOptions);
    // }

    public putTurn(request: any): Observable<any> {
        return this.http.put<any>(`${this.url}/Turn`, request, this.httpOptions);
    }

    //Input is the simEnvironment, turn attribute CANNOT be null must be greater than 0
    public putXTurns(request: SimEnvironment): Observable<SimEnvironment> {
        return this.http.put<SimEnvironment>(`${this.url}/XTurns`, { params: { sim: request } });
    }

    //Requires a size for the terrain square to be larger than 0 and not null
    public putGenerateTerrain(simNum: number): Observable<any> {
        console.log("simnum", simNum);
        var env = this.http.put(`${this.url}/GenerateTerrain`, simNum, this.httpOptions);
        this.setTerrainColor();
        return env;
    }

    public terrainUpdate(request: any): Observable<any>{
        return this.http.put<any>(`${this.url}/terrainUpdate`, request, this.httpOptions);
    }

    // public putGenerateTerrain(simNum: number): Observable<any>{
    //       return this.http.get('https://localhost:7140/api/WildFire/test');
    //   }

    public setEnvironment(env: SimEnvironment) {
        this.setTerrainColor;
        this.Environment = env;
    }

    public getEnvironment(): any {
        // if (this.Environment != undefined) {
            
        // }
        this.setTerrainColor();
        return this.Environment;
    }

    public setTerrainColor(): void {
        for (var i = 0; i < this.Environment?.Terrain.length; i++) {
            for (var j = 0; j < this.Environment.Terrain[i].Terrains.length; j++) {
                switch (this.Environment.Terrain[i].Terrains[j].TerrainType) {
                    case TerrainType.Sand:
                        this.Environment.Terrain[i].Terrains[j].terrainColor = TerrainType[this.Environment.Terrain[i].Terrains[j].TerrainType];
                        break;
                    case TerrainType.Concrete:
                        this.Environment.Terrain[i].Terrains[j].terrainColor = TerrainType[this.Environment.Terrain[i].Terrains[j].TerrainType];
                        break;
                    case TerrainType.WetFlammableFuel:
                        this.Environment.Terrain[i].Terrains[j].terrainColor = TerrainType[this.Environment.Terrain[i].Terrains[j].TerrainType];
                        break;
                    case TerrainType.DryFlammableFuel:
                        this.Environment.Terrain[i].Terrains[j].terrainColor = TerrainType[this.Environment.Terrain[i].Terrains[j].TerrainType];
                        break;
                    case TerrainType.WetLessFlammableFuel:
                        this.Environment.Terrain[i].Terrains[j].terrainColor = TerrainType[this.Environment.Terrain[i].Terrains[j].TerrainType];
                        break;
                    case TerrainType.DryLessFlammableFuel:
                        this.Environment.Terrain[i].Terrains[j].terrainColor = TerrainType[this.Environment.Terrain[i].Terrains[j].TerrainType];
                        break;
                    case TerrainType.Water:
                        this.Environment.Terrain[i].Terrains[j].terrainColor = TerrainType[this.Environment.Terrain[i].Terrains[j].TerrainType];
                        break;
                    default:
                    case TerrainType.Sand:
                        this.Environment.Terrain[i].Terrains[j].terrainColor = "notype";
                        break;

                }
            }
        }
    }
}
