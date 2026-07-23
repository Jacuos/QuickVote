    const options : { title: string; id: number }[] = [
  { title: 'Cabbage', id: 1 },
  { title: 'Garlic', id: 2 },
  { title: 'Apple', id: 3 },
];

export function PollForm() {

    const listItems = options.map(option =>
  <li key={option.id}>
     {option.id}.
     <input type="text" id="option{option.id}" name="option{option.id}"
        value={option.title}
        onChange={i => handleOptionChange(option.id, i.target.value)} /><br />
  </li>
);
function handleOptionChange(id: number, newTitle: string) {

}


    return (
        <>
            <div className="w-full space-y-6 px-4 justify-items-center text-center">
                <nav className="rounded-3xl border border-gray-200 p-6 dark:border-gray-700 space-y-4 ">
                    <p className="leading-6 text-gray-700 dark:text-gray-200">
                        Create quick poll below:
                    </p>
                    <form onSubmit={handleSubmit}>
                        <label>Question:</label><br />
                        <input type="text" id="question" name="question" defaultValue="What is love?" /><br />
                        <label>Last name:</label><br />
                        <input type="text" id="lname" name="lname" defaultValue="Doe" /><br /><br />
                        <input className="bg-blue-500 hover:bg-blue-400 text-white font-bold py-2 px-4 border-b-4 border-blue-700 hover:border-blue-500 rounded" type="submit" value="SEND"/>
                        <ul>{listItems}</ul>
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
            question: { value: string };
            lname: { value: string };
        };
        const question = target.question.value;
        const lastName = target.lname.value;
        const optionsJoin = options.map(option => option.title).join(", ");
        alert(`You asked for '${question}' + '${lastName}' + '${optionsJoin}'`);
    }
}