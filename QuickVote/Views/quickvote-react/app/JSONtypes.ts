
type PollDTOType = {
    poll: PollType
    options: PollOptionType[]
}

type PollType = {
    pollID: string
    question: string
    endDate: Date
}

type PollOptionType = {
    optionID: number
    pollID: string
    description: string
}
