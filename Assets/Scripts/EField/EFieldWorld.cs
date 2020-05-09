using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Unity.Mathematics;

/*
namespace MarchingCubes.EField
{
    /// <summary>
    /// A procedurally generated world
    /// </summary>
    public class ProceduralWorld : World
    {
        /// <summary> The procedural terrain generation settings </summary>
        [SerializeField] private EFieldTerrainSettings _eFieldTerrainSettings = 
            new EFieldTerrainSettings((float)9e-12, 0.5f, 100000f, new Vector3(12,3,12));

        /// <summary> The viewer which the terrain is generated around </summary>
        [SerializeField] private Transform player;

        /// <summary> The point where terrain was last generated around </summary>
        private Vector3 _startPos;

        /// <summary> The pooled chunks that can be moved to a new position </summary>
        private Queue<EFieldChunk> _availableChunks;

        public EFieldTerrainSettings EFieldTerrainSettings => _eFieldTerrainSettings;

        private void Awake()
        {
            _availableChunks = new Queue<EFieldChunk>();
        }

        private int renderDistance = 4;
        protected override void Start()
        {
            base.Start();
            GenerateNewTerrain();
        }

        private void Update()
        {
            if (Mathf.Abs(player.position.x - _startPos.x) >= ChunkSize ||
                Mathf.Abs(player.position.y - _startPos.y) >= ChunkSize ||
                Mathf.Abs(player.position.z - _startPos.z) >= ChunkSize)
            {
                GenerateNewTerrain(player.position);
            }
        }

        /// <summary> Generates new procedural terrain </summary>
        /// <param name="playerPos">The position to generate the terrain around</param>
        private void GenerateNewTerrain(Vector3 playerPos)
        {
            int3 playerCoordinate = WorldPositionToCoordinate(playerPos);

            _availableChunks.Clear();

            foreach (var chunk in Chunks.Values.ToList())
            {
                int xOffset = Mathf.Abs(chunk.Coordinate.x - playerCoordinate.x);
                int yOffset = Mathf.Abs(chunk.Coordinate.y - playerCoordinate.y);
                int zOffset = Mathf.Abs(chunk.Coordinate.z - playerCoordinate.z);

                if (xOffset > renderDistance || yOffset > renderDistance || zOffset > renderDistance)
                {
                    // This conversion always succeeds because we are always adding only EFieldChunks to Chunks.
                    _availableChunks.Enqueue(chunk as EFieldChunk);
                    Chunks.Remove(chunk.Coordinate);
                }
            }

            for (int x = -renderDistance; x <= renderDistance; x++)
            {
                for (int y = -renderDistance; y <= renderDistance; y++)
                {
                    for (int z = -renderDistance; z <= renderDistance; z++)
                    {
                        int3 chunkCoordinate = playerCoordinate + new int3(x, y, z);

                        // Make sure that there is a chunk at that coordinate
                        bool chunkExists = GetOrCreateChunk(chunkCoordinate, out Chunk chunk);
                        if (!chunkExists)
                        { 
                            Chunks.Add(chunkCoordinate, chunk);
                        }
                    }
                }
            }

            _startPos = playerPos;
        }
        
        /// <summary>
        /// Ensures that a chunk exists at a coordinate. It either moves (from availableChunks) or instantiates a chunk
        /// </summary>
        /// <param name="chunkCoordinate">The chunk's coordinate</param>
        /// <param name="chunk">The chunk at that position</param>
        /// <returns>Does a chunk already exist there</returns>
        private bool GetOrCreateChunk(int3 chunkCoordinate, out Chunk chunk)
        {
            if (Chunks.TryGetValue(chunkCoordinate, out Chunk existingChunk))
            {
                chunk = existingChunk;
                return true;
            }

            if (_availableChunks.Count > 0)
            {
                EFieldChunk EFieldChunk = _availableChunks.Dequeue();
                EFieldChunk.SetCoordinate(chunkCoordinate);
                chunk = EFieldChunk;
                return false;
            }

            chunk = CreateChunk(chunkCoordinate);
            return false;
        }

        /// <summary>
        /// Instantiates a chunk at a coordinate
        /// </summary>
        /// <param name="chunkCoordinate">The chunk's coordinate</param>
        /// <returns>The created chunk</returns>
        private EFieldChunk CreateChunk(int3 chunkCoordinate)
        {
            EFieldChunk chunk = Instantiate(ChunkPrefab, (chunkCoordinate * ChunkSize).ToVectorInt(), Quaternion.identity).GetComponent<EFieldChunk>();
            chunk.World = this;
            chunk.Initialize(ChunkSize, Isolevel, chunkCoordinate);

            return chunk;
        }
    }
}
*/