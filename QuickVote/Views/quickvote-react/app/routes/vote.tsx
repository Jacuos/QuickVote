import type { Route } from "./+types/vote";
import { Welcome } from "../welcome/welcome";
import React, { useState, useEffect } from "react";
import { ServerConfig } from "../serverconfig"
import { Link } from "react-router";


export default function Vote({ params }: Route.ComponentProps) {
    const [poll, setPoll] = useState<PollDTOType>();
    const [dataIsLoaded, setDataIsLoaded] = useState(false);
    useEffect(() => {
        fetch(ServerConfig.serverURL + "api/polls/"+params.pollID)
            .then((res) => res.json())
            .then((json) => {
                setPoll(json);
                setDataIsLoaded(true);
            });
    }, []); 

    if (!dataIsLoaded) {
        return (
            <div>
                <h1>Please wait some time....</h1>
            </div>
        );
    }
    if (!poll?.poll) {
        return <VoteErrorHandle pollID={"dupa"} />;
    }
    else {
        return (
            <>
                <main className="justify-items-center pt-8 pb-4 min-h-200">
                    <Welcome />
                    <div>
                        {poll!.poll.question}
                        <table>
                            <tbody>
                                {poll!.options.map((option, index) => (
                                    <tr className="item" key={option.optionID}>
                                        <td>{index + 1}. {option.description}</td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    </div>
                    <br /><br /><br /><br />
                    <footer className="position-fixed bottom-0"><p>PollID: {params.pollID}</p></footer>
                </main>
            </>
        );
    }
}

export function VoteErrorHandle( pollID: string) {
    return (
        <>
            <main className="justify-items-center pt-8 pb-4 min-h-200">
                <Welcome />
                <div>
                    Oops! It seems that you typed wrong poll ID. Please use an existing poll ID or create a new poll.
                </div>
                <br />
                <div>
                    <Link to="/">
                        <button className="bg-blue-500 hover:bg-blue-400 text-white font-bold py-2 px-4 border-b-4 border-blue-700 hover:border-blue-500 rounded"
                        >Go Home</button>
                    </Link>
                </div>
                <br /><br /><br /><br />
                <footer className="position-fixed bottom-0"><p>PollID: {pollID}</p></footer>
            </main>
        </>
    );
}
