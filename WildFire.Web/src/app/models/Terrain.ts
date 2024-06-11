import { FireState } from "../enum/FireState.enum";
import { TerrainType } from "../enum/TerrainTypes.enum";

export interface Terrain{
    terrainType: TerrainType;
    agentOnFirePercentage: number;
    fireState: FireState;
    waterPercentage: number;
    percentageOfFuel: number;

}