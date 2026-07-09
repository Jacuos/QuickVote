

export function PollForm() {
    return (
        <>
        <br></br>
            <div className="w-full space-y-6 px-4 justify-items-center text-center">
                <nav className="rounded-3xl border border-gray-200 p-6 dark:border-gray-700 space-y-4 ">
                    <p className="leading-6 text-gray-700 dark:text-gray-200">
                        Create quick poll below:
                    </p>
                    <button className="bg-blue-500 hover:bg-blue-400 text-white font-bold py-2 px-4 border-b-4 border-blue-700 hover:border-blue-500 rounded"
                    >SEND</button>
                </nav>
            </div>
        </>
    )
}