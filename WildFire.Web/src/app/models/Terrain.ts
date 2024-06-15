import { FireState } from "../enum/FireState.enum";
import { TerrainType } from "../enum/TerrainTypes.enum";

export interface Terrain{
    TerrainType: TerrainType;
    AgentOnFirePercentage: number;
    FireState: FireState;
    WaterPercentage: number;
    PercentageOfFuel: number;
    terrainColor: string;
}