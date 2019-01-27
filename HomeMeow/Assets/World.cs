using UnityEngine;

public class World {
    
    private Vector2[] enemySpawnPoints;
    private Vector2[] itemSpawnPoints;

    private Island[] islands;
    private int[,] world;

    // configurable parameters
    public int width = 20;
    public int height = 20;

    public int islandMaxWidth = 10;
    public int islandMaxHeight = 10;
    public int islandMinWidth = 4;
    public int islandMinHeight = 4;

    private bool built = false;

    private GameObject floor;
    private GameObject water;

    private Material planeMat;
    private Material waterMat;

    public World(Material planeMat, Material waterMat) { this.planeMat = planeMat; this.waterMat = waterMat; }

    public void build() {
        if (built) {
            destroy();
        }

        this.generateWorld();
        this.generateIsland();
        this.generateIsland();
        this.generateItems();
        this.generateMeshes();
        
        built = true;
    }

    private void destroy() {
        if(floor) {
            GameObject.Destroy(floor);
        }
        if(water) {
            GameObject.Destroy(water);
        }
    }

    public void generateMeshes() {
        this.floor = ProceduralHelper.CreateRandomFloor(width, height, 0, planeMat, this.world);
        this.water = ProceduralHelper.CreateRandomFloor(width, height, 0, waterMat, createFlatWorld(width, height, 0));

        floor.transform.RotateAround(new Vector3(0,0,0), new Vector3(1, 0, 0), 180);
        floor.transform.localScale = new Vector3(5, 2, 5);
        water.transform.RotateAround(new Vector3(0,0,0), new Vector3(1, 0, 0), 180);
        water.transform.localScale = new Vector3(5, 2, 5);
    }

    public void generateWorld() {
        this.world = World.createFlatWorld(this.width, this.height, 0);
    }

    public void generateIsland() {
        Vector2 point = RandomGenerator.point(0, this.width, 0, this.height);
        int radius = (int)RandomGenerator.between(4, 10);
        
        for (int z = -radius; z <= radius; z++) {
            for (int x = -radius; x<=radius; x++) {
                if (x*x + z*z <= radius*radius) {
                    if (point.x+x >= 0 && point.y+z >= 0 && point.x+x < width+1 && point.y+z < height+1) {
                        this.world[(int)point.x+x, (int)point.y+z] -= (int)(Random.value + 1);
                    }
                }
            }
        }

        if(this.islands != null) {
            Island[] islands = new Island[this.islands.Length + 1];
            for(int i = 0; i < this.islands.Length; i++) {
                islands[i] = this.islands[i];
            }
            islands[islands.Length - 1] = new Island((int)point.x, (int)point.y, radius);
        } else {
            this.islands = new Island[] {
                new Island((int)point.x, (int)point.y, radius)
            };
        }
        
    }

    public void generateItems() {
        for(int i = 0; i < islands.Length; i++) {
            Island isle = islands[i];

            Vector2 point = RandomGenerator.pointOnCircle(isle.centerX, isle.centerY, isle.radius);
            GameObject cat = GameObject.FindWithTag("cat");

            if (!(point.x >= 0 && point.y >= 0 && point.x < width && point.y < height)) {
                i--;
                continue;
            }

            // int floorHeight = 5;
            int floorHeight = Mathf.CeilToInt(this.world[(int)point.x, (int)point.y]);
            
            GameObject.Instantiate(cat, new Vector3(point.x, floorHeight, point.y), new Quaternion());
        }
    }

    /**
     * INTERNAL BELOW
     */

    private static int[,] createFlatWorld(int width, int height, int val) {
        int[,] world = new int[width+1, height+1];

        for (int z = 0; z <= height; z++) {
            for (int x = 0; x <= width; x++) {
                world[x, z] = val;
            }
        }

        return world;
    }

}