﻿using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

var githubPipeLine = new GithubPipeline
{
    Name = "Sheenam Build Pipeline",

    OnEvents = new Events
    {
        PullRequest = new PullRequestEvent
        {
            Branches = new string[] { "master" }
        },

        Push = new PushEvent
        {
            Branches = new string[] { "master" }
        }
    },

    Jobs = new Jobs
    {
        Build = new BuildJob
        {
            RunsOn = BuildMachines.Windows2022,

            Steps = new List<GithubTask>
            {
                new CheckoutTaskV2
                {
                    Name = "Checking Out Code"
                },

                new SetupDotNetTaskV1
                {
                    Name = "Setting Up .Net",
                    TargetDotNetVersion = new TargetDotNetVersion
                    {
                        DotNetVersion = "6.0.300"
                    }
                },

                new RestoreTask
                {
                    Name = "Restoring Nuget Packages"
                },

                new DotNetBuildTask
                {
                    Name = "Building Project"
                },

                new TestTask
                {
                    Name = "Running Tests"
                }
            }
        }
    }
};

var client = new ADotNetClient();

client.SerializeAndWriteToFile(
    adoPipeline: githubPipeLine,
    path: "../../../../.github/workflows/dotnet.yml");