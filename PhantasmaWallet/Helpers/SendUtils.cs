﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Phantasma.Cryptography;
using Phantasma.RpcClient.DTOs;

namespace Phantasma.Wallet.Helpers
{
    public static class SendUtils
    {
        public static List<ChainDto> SelectShortestPath(string from, string to, List<string> paths, List<ChainDto> phantasmaChains)
        {
            var finalPath = "";
            foreach (var path in paths)
            {
                if (path.IndexOf(from, StringComparison.Ordinal) != -1 && path.IndexOf(to, StringComparison.Ordinal) != -1)
                {
                    if (finalPath == "")
                    {
                        finalPath = path;
                    }
                    else if (path.Count(d => d == ',') < finalPath.Count(d => d == ','))
                    {
                        finalPath = path;
                    }
                }
            }
            var listStrLineElements = finalPath.Split(',').ToList();
            List<ChainDto> chainPath = new List<ChainDto>();
            foreach (var element in listStrLineElements)
            {
                chainPath.Add(phantasmaChains.Find(p => p.Name == element.Trim()));
            }
            return chainPath;
        }

        public static bool IsTxHashValid(string data)
        {
            return Hash.TryParse(data, out Hash result);
        }

        public static List<ChainDto> GetShortestPath(string from, string to, List<ChainDto> phantasmaChains)
        {
            var vertices = new List<string>();
            var edges = new List<Tuple<string, string>>();

            var children = new Dictionary<string, List<ChainDto>>();
            foreach (var chain in phantasmaChains)
            {
                var childs = phantasmaChains.Where(p => p.ParentAddress.Equals(chain.Address));
                if (childs.Any())
                {
                    children[chain.Name] = childs.ToList();
                }
            }

            foreach (var chain in phantasmaChains)
            {
                vertices.Add(chain.Name);
                if (children.ContainsKey(chain.Name))
                {
                    foreach (var child in children[chain.Name])
                    {
                        edges.Add(new Tuple<string, string>(chain.Name, child.Name));
                    }
                }
            }
            var graph = new Graph<string>(vertices, edges);

            var shortestPath = Algorithms.ShortestPathFunction(graph, from);

            List<string> allpaths = new List<string>();
            foreach (var vertex in vertices)
            {
                allpaths.Add(string.Join(", ", shortestPath(vertex)));
            }

            foreach (var allpath in allpaths)
            {
                Debug.WriteLine(allpath);
            }

            return SelectShortestPath(from, to, allpaths, phantasmaChains);
        }
    }
}
