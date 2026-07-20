

export function PollForm() {
    return (
        <>
            <div className="w-full space-y-6 px-4 justify-items-center text-center">
                <nav className="rounded-3xl border border-gray-200 p-6 dark:border-gray-700 space-y-4 ">
                    <p className="leading-6 text-gray-700 dark:text-gray-200">
                        Create quick poll below:
                    </p>
                    <form onSubmit={handleSubmit}>
                        <label>First name:</label><br />
                        <input type="text" id="fname" name="fname" defaultValue="John" /><br />
                        <label>Last name:</label><br />
                        <input type="text" id="lname" name="lname" defaultValue="Doe" /><br /><br />
                        <input className="bg-blue-500 hover:bg-blue-400 text-white font-bold py-2 px-4 border-b-4 border-blue-700 hover:border-blue-500 rounded" type="submit" value="SEND"/>
                    </form>
                </nav>
            </div>
        </>
    )

    function handleSubmit(e: React.SyntheticEvent) {
        // Prevent the browser from reloading the page
        e.preventDefault();

        // Read the form data
        const target = e.target as typeof e.target & {
            fname: { value: string };
            lname: { value: string };
        };
        const firstName = target.fname.value;
        const lastName = target.lname.value;
        alert(`You searched for '${firstName}' + '${lastName}`);
    }
}