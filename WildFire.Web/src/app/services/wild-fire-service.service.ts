import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { SimEnvironment } from "../models/SimEnvironment";
import { Observable } from "rxjs";
import { TerrainType } from '../enum/TerrainTypes.enum';

@Injectable({
    providedIn: 'root'
})
export class WildFireService {

    //This is the API's local address so that the UI can connect to it.
    private readonly url: string = 'https://localhost:7140/api/WildFire';

    httpOptions: any;

    Environment!: SimEnvironment;

    constructor(private readonly http: HttpClient) {

        this.httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) }

    }

    //Input is the simEnvironment, leave the turn attribute null
    public putTurn(request: SimEnvironment): Observable<SimEnvironment> {
        return this.http.put<SimEnvironment>(`${this.url}/Turn`, { params: { sim: request } });
    }

    //Input is the simEnvironment, turn attribute CANNOT be null must be greater than 0
    public putXTurns(request: SimEnvironment): Observable<SimEnvironment> {
        return this.http.put<SimEnvironment>(`${this.url}/XTurns`, { params: { sim: request } });
    }

    //Requires a size for the terrain square to be larger than 0 and not null
    public putGenerateTerrain(simNum: number): Observable<any> {
        console.log("SIOMENUME", simNum);
        var env = this.http.put(`${this.url}/GenerateTerrain`, simNum, this.httpOptions);
        this.setTerrainColor();
        return env;
    }

    // public putGenerateTerrain(simNum: number): Observable<any>{
    //       return this.http.get('https://localhost:7140/api/WildFire/test');
    //   }

    public setEnvironment(env: SimEnvironment) {
        this.setTerrainColor;
        this.Environment = env;
    }

    public getEnvironment(): any {
        if (this.Environment != undefined) {
            this.setTerrainColor();
            return this.Environment;
        }
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
                console.log("color picker");
                console.log(this.Environment.Terrain[i].Terrains[j].TerrainType)
                console.log(this.Environment.Terrain[i].Terrains[j].TerrainType.toString())
                console.log(TerrainType[this.Environment.Terrain[i].Terrains[j].TerrainType])
            }
        }
    }
}
