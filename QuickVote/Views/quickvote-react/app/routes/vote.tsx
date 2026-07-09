import type { Route } from "./+types/vote";
import { Welcome } from "../welcome/welcome";
import React, { useState, useEffect } from "react";
import { ServerConfig } from "../serverconfig"


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
    return (
        <>
            <main className="justify-items-center pt-8 pb-4 min-h-200">
            <Welcome />
                <div>
                    {poll!.poll.question}
                    <table>
                        <tbody>
                            {poll!.options.map((option,index) => (
                                <tr className="item" key={option.optionID}>
                                    <td>{index+1}. {option.description}</td>
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
