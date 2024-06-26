export const formatDate = (date: Date | undefined): string => {
    if (date === undefined) {
        throw new Error('La fecha es undefined.');
    }
    return new Date(date).toLocaleDateString('en-ZA');
};
